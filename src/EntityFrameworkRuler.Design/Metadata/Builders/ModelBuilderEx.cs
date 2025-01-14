﻿using EntityFrameworkRuler.Common.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

namespace EntityFrameworkRuler.Design.Metadata.Builders;

/// <summary> This is an internal API and is subject to change or removal without notice. </summary>
public class ModelBuilderEx : IConventionModelBuilder {
    private readonly IConventionModelBuilder conventionModelBuilder;

    /// <summary> This is an internal API and is subject to change or removal without notice. </summary>
    public ModelBuilderEx(ModelBuilder builder) {
        Builder = builder;
        conventionModelBuilder = ((IInfrastructure<IConventionModelBuilder>)builder).Instance;
        ModelEx = new(this);
    }

    /// <summary> This is an internal API and is subject to change or removal without notice. </summary>
    public ModelEx ModelEx { get; }

    /// <summary> This is an internal API and is subject to change or removal without notice. </summary>
    public IMutableModel Model => Builder.Model;

    /// <summary> This is an internal API and is subject to change or removal without notice. </summary>
    public ModelBuilder Builder { get; }


    /// <summary>
    ///     Returns an object that can be used to configure a given entity type in the model.
    ///     If an entity type with the provided name is not already part of the model,
    ///     a new entity type that does not have a corresponding CLR type will be added to the model.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types</see> for more information and examples.
    /// </remarks>
    /// <param name="name">The name of the entity type to be configured.</param>
    /// <returns>An object that can be used to configure the entity type.</returns>
    public virtual FunctionBuilder CreateFunction(string name) {
        return ModelEx.CreateFunction(name);
    }

    #region IConventionAnnotatableBuilder impl

    IConventionAnnotatableBuilder IConventionAnnotatableBuilder.HasAnnotation(string name, object value, bool fromDataAnnotation) {
        return conventionModelBuilder.HasAnnotation(name, value, fromDataAnnotation);
    }


    IConventionAnnotatableBuilder IConventionAnnotatableBuilder.HasNonNullAnnotation(string name, object value, bool fromDataAnnotation) {
        return conventionModelBuilder.HasNonNullAnnotation(name, value, fromDataAnnotation);
    }

    bool IConventionAnnotatableBuilder.CanSetAnnotation(string name, object value, bool fromDataAnnotation) {
        return conventionModelBuilder.CanSetAnnotation(name, value, fromDataAnnotation);
    }

    IConventionAnnotatableBuilder IConventionAnnotatableBuilder.HasNoAnnotation(string name, bool fromDataAnnotation) {
        return conventionModelBuilder.HasNoAnnotation(name, fromDataAnnotation);
    }

    bool IConventionAnnotatableBuilder.CanRemoveAnnotation(string name, bool fromDataAnnotation) {
        return conventionModelBuilder.CanRemoveAnnotation(name, fromDataAnnotation);
    }


    IConventionModel IConventionModelBuilder.Metadata => conventionModelBuilder.Metadata;

    IConventionEntityTypeBuilder IConventionModelBuilder.Entity(string name, bool? shouldBeOwned, bool fromDataAnnotation) {
        return conventionModelBuilder.Entity(name, shouldBeOwned, fromDataAnnotation);
    }

    IConventionEntityTypeBuilder IConventionModelBuilder.SharedTypeEntity(string name, Type type, bool? shouldBeOwned, bool fromDataAnnotation) {
        return conventionModelBuilder.SharedTypeEntity(name, type, shouldBeOwned, fromDataAnnotation);
    }

    IConventionEntityTypeBuilder IConventionModelBuilder.Entity(Type type, bool? shouldBeOwned, bool fromDataAnnotation) {
        return conventionModelBuilder.Entity(type, shouldBeOwned, fromDataAnnotation);
    }

    IConventionEntityTypeBuilder IConventionModelBuilder.Entity(string name, string definingNavigationName, IConventionEntityType definingEntityType, bool fromDataAnnotation) {
        return conventionModelBuilder.Entity(name, definingNavigationName, definingEntityType, fromDataAnnotation);
    }

    IConventionEntityTypeBuilder IConventionModelBuilder.Entity(Type type, string definingNavigationName, IConventionEntityType definingEntityType, bool fromDataAnnotation) {
        return conventionModelBuilder.Entity(type, definingNavigationName, definingEntityType, fromDataAnnotation);
    }

    IConventionOwnedEntityTypeBuilder IConventionModelBuilder.Owned(Type type, bool fromDataAnnotation) {
        return conventionModelBuilder.Owned(type, fromDataAnnotation);
    }


    bool IConventionModelBuilder.IsIgnored(Type type, bool fromDataAnnotation) {
        return conventionModelBuilder.IsIgnored(type, fromDataAnnotation);
    }

    bool IConventionModelBuilder.IsIgnored(string typeName, bool fromDataAnnotation) {
        return conventionModelBuilder.IsIgnored(typeName, fromDataAnnotation);
    }

    IConventionModelBuilder IConventionModelBuilder.Ignore(Type type, bool fromDataAnnotation) {
        return conventionModelBuilder.Ignore(type, fromDataAnnotation);
    }

    IConventionModelBuilder IConventionModelBuilder.Ignore(string typeName, bool fromDataAnnotation) {
        return conventionModelBuilder.Ignore(typeName, fromDataAnnotation);
    }


    IConventionModelBuilder IConventionModelBuilder.HasNoEntityType(IConventionEntityType entityType, bool fromDataAnnotation) {
        return conventionModelBuilder.HasNoEntityType(entityType, fromDataAnnotation);
    }

    bool IConventionModelBuilder.CanIgnore(Type type, bool fromDataAnnotation) {
        return conventionModelBuilder.CanIgnore(type, fromDataAnnotation);
    }

    bool IConventionModelBuilder.CanIgnore(string typeName, bool fromDataAnnotation) {
        return conventionModelBuilder.CanIgnore(typeName, fromDataAnnotation);
    }

    IConventionModelBuilder IConventionModelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy? changeTrackingStrategy, bool fromDataAnnotation) {
        return conventionModelBuilder.HasChangeTrackingStrategy(changeTrackingStrategy, fromDataAnnotation);
    }

    bool IConventionModelBuilder.CanSetChangeTrackingStrategy(ChangeTrackingStrategy? changeTrackingStrategy, bool fromDataAnnotation) {
        return conventionModelBuilder.CanSetChangeTrackingStrategy(changeTrackingStrategy, fromDataAnnotation);
    }

    IConventionModelBuilder IConventionModelBuilder.UsePropertyAccessMode(PropertyAccessMode? propertyAccessMode, bool fromDataAnnotation) {
        return conventionModelBuilder.UsePropertyAccessMode(propertyAccessMode, fromDataAnnotation);
    }

    bool IConventionModelBuilder.CanSetPropertyAccessMode(PropertyAccessMode? propertyAccessMode, bool fromDataAnnotation) {
        return conventionModelBuilder.CanSetPropertyAccessMode(propertyAccessMode, fromDataAnnotation);
    }


    IConventionAnnotatable IConventionAnnotatableBuilder.Metadata => ((IConventionAnnotatableBuilder)conventionModelBuilder).Metadata;

    IConventionModelBuilder IConventionAnnotatableBuilder.ModelBuilder => conventionModelBuilder.ModelBuilder;

    #endregion

#if NET8_0_OR_GREATER
    public IConventionModelBuilder ComplexType(Type type, bool fromDataAnnotation = false) {
        return conventionModelBuilder.ComplexType(type, fromDataAnnotation);
    }

    public IConventionModelBuilder HasNonNullAnnotation(string name, object value, bool fromDataAnnotation = false) {
        return conventionModelBuilder.HasNonNullAnnotation(name, value, fromDataAnnotation);
    }

    public IConventionModelBuilder HasNoAnnotation(string name, bool fromDataAnnotation = false) {
        return conventionModelBuilder.HasNoAnnotation(name, fromDataAnnotation);
    }

    public IConventionModelBuilder HasAnnotation(string name, object value, bool fromDataAnnotation = false) {
        return conventionModelBuilder.HasAnnotation(name, value, fromDataAnnotation);
    }

    public bool CanHaveEntity(string name, bool fromDataAnnotation = false) {
        return conventionModelBuilder.CanHaveEntity(name, fromDataAnnotation);
    }

    public bool CanHaveEntity(Type type, bool fromDataAnnotation = false) {
        return conventionModelBuilder.CanHaveEntity(type, fromDataAnnotation);
    }

    public bool CanHaveSharedTypeEntity(string name, Type type, bool fromDataAnnotation = false) {
        return conventionModelBuilder.CanHaveSharedTypeEntity(name, type, fromDataAnnotation);
    }

    public bool CanRemoveEntity(IConventionEntityType entityType, bool fromDataAnnotation = false) {
        return conventionModelBuilder.CanRemoveEntity(entityType, fromDataAnnotation);
    }
#endif
#if NET9_0_OR_GREATER
    public bool CanSetEmbeddedDiscriminatorName(string name, bool fromDataAnnotation = false) {
        return conventionModelBuilder.CanSetEmbeddedDiscriminatorName(name, fromDataAnnotation);
    }

    public IConventionModelBuilder HasEmbeddedDiscriminatorName(string name, bool fromDataAnnotation = false) {
        return conventionModelBuilder.HasEmbeddedDiscriminatorName(name, fromDataAnnotation);
    }
#endif
}